//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UDEOExceptionless
{
    using System;
    using System.Collections.Generic;
    
    public partial class donacion_balance
    {
        public int Id { get; set; }
        public int donacion_id { get; set; }
        public int balance_id { get; set; }
    
        public virtual Balance Balance { get; set; }
        public virtual Donacion Donacion { get; set; }
    }
}