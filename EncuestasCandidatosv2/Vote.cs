//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncuestasCandidatosv2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vote
    {
        public int ID_Vote { get; set; }
        public int ID_Candidate { get; set; }
        public int ID_Place { get; set; }
        public int ID_Position { get; set; }
        public string DOC_VoteForm { get; set; }
    
        public virtual Candidate Candidate { get; set; }
        public virtual Place Place { get; set; }
        public virtual Position Position { get; set; }
    }
}