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
    
    public partial class AnswerOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnswerOption()
        {
            this.ExamAnswers = new HashSet<ExamAnswer>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public bool AnswerStatus { get; set; }
        public int QuestionRefId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAnswer> ExamAnswers { get; set; }
        public virtual Question Question { get; set; }
    }
}
