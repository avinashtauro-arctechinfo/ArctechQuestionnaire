//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Questionnaire.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamQuestion()
        {
            this.ExamAnswers = new HashSet<ExamAnswer>();
        }
    
        public int Id { get; set; }
        public int ExamRefId { get; set; }
        public int QuestionRefId { get; set; }
    
        public virtual Exam Exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAnswer> ExamAnswers { get; set; }
        public virtual Question Question { get; set; }
    }
}
