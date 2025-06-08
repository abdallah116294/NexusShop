using System.ComponentModel.DataAnnotations;

namespace Nexus.Models.Models
{
    public class Category
    {

        #region Properties
        /// Primary key for the category
        /// Using The Data Annotations to specify the primary key
        [Key]
        public int Id { get; set; }
        ///Name of the category make it required and max length of 100 characters
        /// Using Data Annotations to specify the required and max length constraints
        [Required(ErrorMessage = "Category Name is required")]
        [MaxLength(100, ErrorMessage = "Category Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="Display Order must be between 1-100")]
        public int DisplatOrder { get; set; } 
        #endregion

    }
}
