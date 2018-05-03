namespace AMQH.Models.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [DisplayName("������ϸ")]
    [DisplayColumn("Name")]
    public partial class Order
    {
       

        [Key]
        public int Id { get; set; }


        
        public int OHeaderId { get; set; }

        [DisplayName("�ܼ�")]
        [Required(ErrorMessage = "�������ܼ�")]
        [Description("������Ʒ�ۼۻᾭ�������춯����˱��뱣����������Ʒ�ļ۸�")]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

        [DisplayName("ѡ������")]
        [Required]
        public int Amount { get; set; }

        [DisplayName("����ͼ��")]
        [Required]
        public virtual Book Book { get; set; }

        [DisplayName("�������ļ�")]
        [Required]
        public virtual OrderHeaders OrderHeaders { get; set; }
    }
}
