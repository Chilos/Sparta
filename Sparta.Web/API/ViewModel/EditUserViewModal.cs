using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sparta.Web.API.ViewModel
{
    public class EditUserViewModal : UserViewModal
    {
        public string Id { get; set; }
        public bool IsDropPassword { get; set; }
    }
}
