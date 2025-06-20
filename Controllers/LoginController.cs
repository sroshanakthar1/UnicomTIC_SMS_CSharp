using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class LoginController
    {
        private readonly DatabaseManager _dbManager;

        public LoginController()
        {
            _dbManager = new DatabaseManager();
        }

        public User AuthenticateUser(string username, string password)
        {
            return _dbManager.GetUserByUsernameAndPassword(username, password);
        }
    }
}