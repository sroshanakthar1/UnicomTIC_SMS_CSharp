using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using UnicomTICManagementSystem.Models; 

namespace UnicomTICManagementSystem.Repositories
{
    public class DatabaseManager
    {
        private readonly string _databasePath;
        private readonly string _connectionString;

        public DatabaseManager()
        {
            
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _databasePath = Path.Combine(appDirectory, "unicomtic.db");
            _connectionString = $"Data Source={_databasePath};Version=3;";
        }

        
        public void InitializeDatabase() 
        {
            
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
                Console.WriteLine("Database file created successfully.");
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open(); // Open connection synchronously

                
                string createTablesSql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL, -- Storing plain text as per assignment for simplicity
                        Role TEXT NOT NULL --
                    );

                    CREATE TABLE IF NOT EXISTS Courses (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL UNIQUE
                    );

                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );

                    CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );

                    CREATE TABLE IF NOT EXISTS Exams (
                        ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );

                    CREATE TABLE IF NOT EXISTS Marks (
                        MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        ExamID INTEGER NOT NULL,
                        Score INTEGER NOT NULL CHECK(Score >= 0 AND Score <= 100), -- Score 0-100
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
                    );

                    CREATE TABLE IF NOT EXISTS Rooms (
                        RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL UNIQUE,
                        RoomType TEXT NOT NULL, -- e.g., 'Lab', 'Lecture Hall'
                        Capacity INTEGER NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS TimetableEntries (
                        EntryID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        RoomID INTEGER NOT NULL,
                        Day INTEGER NOT NULL,      -- Stored as integer (0=Sunday, 1=Monday, etc.)
                        StartTime TEXT NOT NULL,   -- Stored as TEXT (HH:MM:SS)
                        EndTime TEXT NOT NULL,     -- Stored as TEXT (HH:MM:SS)
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                        FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
                    );
                ";

                using (var command = new SQLiteCommand(createTablesSql, connection))
                {
                    command.ExecuteNonQuery(); // Execute table creation synchronously
                    Console.WriteLine("Tables created or already exist.");
                }

                InsertInitialData(connection); // Insert default data synchronously
            }
        }

        
        private void InsertInitialData(SQLiteConnection connection)
        {
            // Add a default 'Admin' user if not already present
            using (var checkAdminCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Username = 'admin1'", connection))
            {
                if (Convert.ToInt32(checkAdminCmd.ExecuteScalar()) == 0)
                {
                    using (var insertAdminCmd = new SQLiteCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", connection))
                    {
                        insertAdminCmd.Parameters.AddWithValue("@username", "admin1");
                        insertAdminCmd.Parameters.AddWithValue("@password", "pass123");
                        insertAdminCmd.Parameters.AddWithValue("@role", "Admin");
                        insertAdminCmd.ExecuteNonQuery();
                        Console.WriteLine("Default Admin user added.");
                    }
                }
            }

            // Add a default 'Staff' user if not already present
            using (var checkStaffCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Username = 'staff1'", connection))
            {
                if (Convert.ToInt32(checkStaffCmd.ExecuteScalar()) == 0)
                {
                    using (var insertStaffCmd = new SQLiteCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", connection))
                    {
                        insertStaffCmd.Parameters.AddWithValue("@username", "staff1");
                        insertStaffCmd.Parameters.AddWithValue("@password", "staffpass");
                        insertStaffCmd.Parameters.AddWithValue("@role", "Staff");
                        insertStaffCmd.ExecuteNonQuery();
                        Console.WriteLine("Default 'staff1' user added.");
                    }
                }
            }

            // Add a default 'Lecturer' user if not already present
            using (var checkLecturerCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Username = 'lecturer1'", connection))
            {
                if (Convert.ToInt32(checkLecturerCmd.ExecuteScalar()) == 0)
                {
                    using (var insertLecturerCmd = new SQLiteCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", connection))
                    {
                        insertLecturerCmd.Parameters.AddWithValue("@username", "lecturer1");
                        insertLecturerCmd.Parameters.AddWithValue("@password", "lecpass");
                        insertLecturerCmd.Parameters.AddWithValue("@role", "Lecturer");
                        insertLecturerCmd.ExecuteNonQuery();
                        Console.WriteLine("Default 'lecturer1' user added.");
                    }
                }
            }

            // Add a default 'Student' user if not already present
            using (var checkStudentUserCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Username = 'student1'", connection))
            {
                if (Convert.ToInt32(checkStudentUserCmd.ExecuteScalar()) == 0)
                {
                    using (var insertStudentUserCmd = new SQLiteCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", connection))
                    {
                        insertStudentUserCmd.Parameters.AddWithValue("@username", "student1");
                        insertStudentUserCmd.Parameters.AddWithValue("@password", "stupass");
                        insertStudentUserCmd.Parameters.AddWithValue("@role", "Student");
                        insertStudentUserCmd.ExecuteNonQuery();
                        Console.WriteLine("Default 'student1' user added.");
                    }
                }
            }


        }

        
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public UnicomTICManagementSystem.Models.User? GetUserByUsernameAndPassword(string username, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // Ensure 'Role' is selected in the query
                string query = "SELECT UserID, Username, Password, Role FROM Users WHERE Username = @username AND Password = @password LIMIT 1";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UnicomTICManagementSystem.Models.User
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Role = reader.GetString(reader.GetOrdinal("Role")) 
                            };
                        }
                    }
                }
            }
            return null; // User not found
        }

        public void AddCourse(Course course)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Courses (CourseName) VALUES (@courseName)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseName", course.CourseName);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all Courses from the database
        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT CourseID, CourseName FROM Courses";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseID = reader.GetInt32(reader.GetOrdinal("CourseID")),
                                CourseName = reader.GetString(reader.GetOrdinal("CourseName"))
                            });
                        }
                    }
                }
            }
            return courses;
        }

        // Updates an existing Course in the database
        public void UpdateCourse(Course course)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Courses SET CourseName = @courseName WHERE CourseID = @courseID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseName", course.CourseName);
                    command.Parameters.AddWithValue("@courseID", course.CourseID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes a Course from the database by CourseID
        public void DeleteCourse(int courseId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Courses WHERE CourseID = @courseID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseID", courseId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddSubject(Subject subject)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@subjectName, @courseID)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subjectName", subject.SubjectName);
                    command.Parameters.AddWithValue("@courseID", subject.CourseID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            using (var connection = GetConnection())
            {
                connection.Open();
                // Joining with Courses to potentially get CourseName for display purposes later
                string query = @"
                    SELECT s.SubjectID, s.SubjectName, s.CourseID, c.CourseName
                    FROM Subjects s
                    JOIN Courses c ON s.CourseID = c.CourseID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = reader.GetInt32(reader.GetOrdinal("SubjectID")),
                                SubjectName = reader.GetString(reader.GetOrdinal("SubjectName")),
                                CourseID = reader.GetInt32(reader.GetOrdinal("CourseID"))
                                
                            });
                        }
                    }
                }
            }
            return subjects;
        }

        public void UpdateSubject(Subject subject)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Subjects SET SubjectName = @subjectName, CourseID = @courseID WHERE SubjectID = @subjectID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subjectName", subject.SubjectName);
                    command.Parameters.AddWithValue("@courseID", subject.CourseID);
                    command.Parameters.AddWithValue("@subjectID", subject.SubjectID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Subjects WHERE SubjectID = @subjectID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subjectID", subjectId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddStudent(Student student)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Students (Name, CourseID) VALUES (@name, @courseID)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@courseID", student.CourseID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all Students from the database, optionally joining with Courses to get CourseName
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (var connection = GetConnection())
            {
                connection.Open();
                // Joining with Courses to get CourseName for display in the form
                string query = @"
                    SELECT st.StudentID, st.Name, st.CourseID, c.CourseName
                    FROM Students st
                    JOIN Courses c ON st.CourseID = c.CourseID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                CourseID = reader.GetInt32(reader.GetOrdinal("CourseID"))
                                
                            });
                        }
                    }
                }
            }
            return students;
        }

        // Updates an existing Student in the database
        public void UpdateStudent(Student student)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Students SET Name = @name, CourseID = @courseID WHERE StudentID = @studentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@courseID", student.CourseID);
                    command.Parameters.AddWithValue("@studentID", student.StudentID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes a Student from the database by StudentID
        public void DeleteStudent(int studentId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Students WHERE StudentID = @studentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", studentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddExam(Exam exam)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Exams (ExamName, SubjectID) VALUES (@examName, @subjectID)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@examName", exam.ExamName);
                    command.Parameters.AddWithValue("@subjectID", exam.SubjectID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all Exams from the database, optionally joining with Subjects and Courses
        public List<Exam> GetAllExams()
        {
            List<Exam> exams = new List<Exam>();
            using (var connection = GetConnection())
            {
                connection.Open();
                // Joining with Subjects (and potentially Courses if needed for display)
                string query = @"
                    SELECT e.ExamID, e.ExamName, e.SubjectID, s.SubjectName, c.CourseName
                    FROM Exams e
                    JOIN Subjects s ON e.SubjectID = s.SubjectID
                    JOIN Courses c ON s.CourseID = c.CourseID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exams.Add(new Exam
                            {
                                ExamID = reader.GetInt32(reader.GetOrdinal("ExamID")),
                                ExamName = reader.GetString(reader.GetOrdinal("ExamName")),
                                SubjectID = reader.GetInt32(reader.GetOrdinal("SubjectID"))
                                
                            });
                        }
                    }
                }
            }
            return exams;
        }

        // Updates an existing Exam in the database
        public void UpdateExam(Exam exam)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Exams SET ExamName = @examName, SubjectID = @subjectID WHERE ExamID = @examID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@examName", exam.ExamName);
                    command.Parameters.AddWithValue("@subjectID", exam.SubjectID);
                    command.Parameters.AddWithValue("@examID", exam.ExamID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes an Exam from the database by ExamID
        public void DeleteExam(int examId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Exams WHERE ExamID = @examID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@examID", examId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddMark(Mark mark)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Marks (StudentID, ExamID, Score) VALUES (@studentID, @examID, @score)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", mark.StudentID);
                    command.Parameters.AddWithValue("@examID", mark.ExamID);
                    command.Parameters.AddWithValue("@score", mark.Score);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all Marks from the database, joining with Students and Exams for display names
        public List<Mark> GetAllMarks()
        {
            List<Mark> marks = new List<Mark>();
            using (var connection = GetConnection())
            {
                connection.Open();
                // Joining with Students and Exams to get names for display in the form
                string query = @"
                    SELECT m.MarkID, m.StudentID, s.Name AS StudentName,
                           m.ExamID, e.ExamName, m.Score
                    FROM Marks m
                    JOIN Students s ON m.StudentID = s.StudentID
                    JOIN Exams e ON m.ExamID = e.ExamID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marks.Add(new Mark
                            {
                                MarkID = reader.GetInt32(reader.GetOrdinal("MarkID")),
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                ExamID = reader.GetInt32(reader.GetOrdinal("ExamID")),
                                Score = reader.GetInt32(reader.GetOrdinal("Score"))
                                
                            });
                        }
                    }
                }
            }
            return marks;
        }

        // Updates an existing Mark in the database
        public void UpdateMark(Mark mark)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Marks SET StudentID = @studentID, ExamID = @examID, Score = @score WHERE MarkID = @markID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", mark.StudentID);
                    command.Parameters.AddWithValue("@examID", mark.ExamID);
                    command.Parameters.AddWithValue("@score", mark.Score);
                    command.Parameters.AddWithValue("@markID", mark.MarkID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes a Mark from the database by MarkID
        public void DeleteMark(int markId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Marks WHERE MarkID = @markID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@markID", markId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddRoom(Room room)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Rooms (RoomName, RoomType, Capacity) VALUES (@roomName, @roomType, @capacity)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomName", room.RoomName);
                    command.Parameters.AddWithValue("@roomType", room.RoomType);
                    command.Parameters.AddWithValue("@capacity", room.Capacity);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all Rooms from the database
        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT RoomID, RoomName, RoomType, Capacity FROM Rooms";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new Room
                            {
                                RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                                RoomName = reader.GetString(reader.GetOrdinal("RoomName")),
                                RoomType = reader.GetString(reader.GetOrdinal("RoomType")),
                                Capacity = reader.GetInt32(reader.GetOrdinal("Capacity"))
                            });
                        }
                    }
                }
            }
            return rooms;
        }

        // Updates an existing Room in the database
        public void UpdateRoom(Room room)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Rooms SET RoomName = @roomName, RoomType = @roomType, Capacity = @capacity WHERE RoomID = @roomID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomName", room.RoomName);
                    command.Parameters.AddWithValue("@roomType", room.RoomType);
                    command.Parameters.AddWithValue("@capacity", room.Capacity);
                    command.Parameters.AddWithValue("@roomID", room.RoomID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes a Room from the database by RoomID
        public void DeleteRoom(int roomID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Rooms WHERE RoomID = @roomID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomID", roomID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddTimetableEntry(TimetableEntry entry)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO TimetableEntries (SubjectID, RoomID, Day, StartTime, EndTime) VALUES (@subjectID, @roomID, @day, @startTime, @endTime)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subjectID", entry.SubjectID);
                    command.Parameters.AddWithValue("@roomID", entry.RoomID);
                    command.Parameters.AddWithValue("@day", (int)entry.Day); // Store DayOfWeek as int
                    command.Parameters.AddWithValue("@startTime", entry.StartTime.ToString(@"hh\:mm")); // Store TimeSpan as string
                    command.Parameters.AddWithValue("@endTime", entry.EndTime.ToString(@"hh\:mm"));     // Store TimeSpan as string
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all TimetableEntries from the database, joining with Subjects and Rooms for display
        public List<TimetableEntry> GetAllTimetableEntries()
        {
            List<TimetableEntry> entries = new List<TimetableEntry>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT te.EntryID, te.SubjectID, s.SubjectName,
                           te.RoomID, r.RoomName, r.RoomType,
                           te.Day, te.StartTime, te.EndTime
                    FROM TimetableEntries te
                    JOIN Subjects s ON te.SubjectID = s.SubjectID
                    JOIN Rooms r ON te.RoomID = r.RoomID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entries.Add(new TimetableEntry
                            {
                                EntryID = reader.GetInt32(reader.GetOrdinal("EntryID")),
                                SubjectID = reader.GetInt32(reader.GetOrdinal("SubjectID")),
                                RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                                Day = (DayOfWeek)reader.GetInt32(reader.GetOrdinal("Day")), // Convert int back to DayOfWeek
                                StartTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("StartTime"))), // Convert string back to TimeSpan
                                EndTime = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("EndTime")))     // Convert string back to TimeSpan
                                // SubjectName, RoomName, RoomType are retrieved but will be handled for display in the form
                            });
                        }
                    }
                }
            }
            return entries;
        }

        // Updates an existing TimetableEntry in the database
        public void UpdateTimetableEntry(TimetableEntry entry)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE TimetableEntries SET SubjectID = @subjectID, RoomID = @roomID, Day = @day, StartTime = @startTime, EndTime = @endTime WHERE EntryID = @entryID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subjectID", entry.SubjectID);
                    command.Parameters.AddWithValue("@roomID", entry.RoomID);
                    command.Parameters.AddWithValue("@day", (int)entry.Day);
                    command.Parameters.AddWithValue("@startTime", entry.StartTime.ToString(@"hh\:mm"));
                    command.Parameters.AddWithValue("@endTime", entry.EndTime.ToString(@"hh\:mm"));
                    command.Parameters.AddWithValue("@entryID", entry.EntryID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes a TimetableEntry from the database by EntryID
        public void DeleteTimetableEntry(int entryID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM TimetableEntries WHERE EntryID = @entryID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@entryID", entryID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT UserID, Username, Password, Role FROM Users;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password")), 
                                Role = reader.GetString(reader.GetOrdinal("Role"))
                            });
                        }
                    }
                }
            }
            return users;
        }

        public void AddUser(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role);";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password); 
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password); 
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@UserID", user.UserID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}