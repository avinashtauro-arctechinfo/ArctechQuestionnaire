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
    
    public partial class ExamAnswer
    {
        public int Id { get; set; }
        public int ExamQuestionRefId { get; set; }
        public int AnswerOptionRefId { get; set; }
        public int CandidateRefId { get; set; }
    
        public virtual AnswerOption AnswerOption { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual ExamQuestion ExamQuestion { get; set; }
    }
}
