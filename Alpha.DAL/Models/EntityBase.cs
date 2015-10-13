using System;

namespace Alpha.DAL.Models {
    /// <summary>
    /// Base class for models that implement the soft deletes 
    /// </summary>
    public class EntityBase {
        // This is used to implment soft deletes - bool to say if it is deleted and the datetime for the date of when it was deleted (can be empty)
        public bool IsDeleted { get; set; } = false;
        public DateTime? DateDeleted { get; set; }
    }
}
