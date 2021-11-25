using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GovernmentBidding
{
    public class ApplicationDbContext : DbContext
    {
        // 您的內容已設定為使用應用程式組態檔 (App.config 或 Web.config)
        // 中的 'ApplicationDbContext' 連接字串。根據預設，這個連接字串的目標是
        // 您的 LocalDb 執行個體上的 'GovernmentBidding.ApplicationDbContext' 資料庫。
        // 
        // 如果您的目標是其他資料庫和 (或) 提供者，請修改
        // 應用程式組態檔中的 'ApplicationDbContext' 連接字串。
        public ApplicationDbContext()
            : base("name=calendarDbContext")
        {
        }

        // 針對您要包含在模型中的每種實體類型新增 DbSet。如需有關設定和使用
        // Code First 模型的詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<CaseInfo> CaseInfoes { get; set; }
    }

    public class CaseInfo
    {
        [Key]//主鍵 PK
        [Display(Name = "編號")]//顯示名稱
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自動生成編號
        public int id { get; set; }
        [Required]
        public string AgencyName { get; set; } //機關名稱
        [Required]
        public string CaseNumber { get; set; } //標案案號
        [Required]
        public string CaseName { get; set; } //案件名稱

        public int PublishCount { get; set; } //新增公告傳輸次數

        [Required]
        public string TenderMethod { get; set; } //招標方式

        [Required]
        public string CaseClassify { get; set; } //標的分類

        public DateTime PublishDate { get; set; } //公告日期
        public DateTime EndDate { get; set; } //截標日期
        public int Budget { get; set; } //預算
        
    }

}