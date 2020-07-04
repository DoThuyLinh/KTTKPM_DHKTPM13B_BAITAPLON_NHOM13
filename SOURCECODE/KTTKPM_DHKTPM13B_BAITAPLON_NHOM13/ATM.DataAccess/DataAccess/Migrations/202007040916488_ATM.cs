namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountCards",
                c => new
                    {
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                        AccountType = c.Int(nullable: false),
                        CardCreationDate = c.DateTime(nullable: false),
                        AvailableBalance = c.Double(nullable: false),
                        ForeignFee = c.Int(nullable: false),
                        InternalFee = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        BankID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.BankInfoes", t => t.BankID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.BankID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.BankInfoes",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        BankName = c.String(nullable: false),
                        BankAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BankID);
            
            CreateTable(
                "dbo.ATMInfoes",
                c => new
                    {
                        ATMID = c.Int(nullable: false, identity: true),
                        ATMName = c.String(nullable: false),
                        ATMAddress = c.String(nullable: false),
                        ATMBalance = c.Double(nullable: false),
                        BankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ATMID)
                .ForeignKey("dbo.BankInfoes", t => t.BankID, cascadeDelete: true)
                .Index(t => t.BankID);
            
            CreateTable(
                "dbo.ATMHistories",
                c => new
                    {
                        ATMHistoryID = c.Int(nullable: false, identity: true),
                        ATMHistoryTime = c.DateTime(nullable: false),
                        ATMID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ATMHistoryID)
                .ForeignKey("dbo.ATMInfoes", t => t.ATMID, cascadeDelete: true)
                .Index(t => t.ATMID);
            
            CreateTable(
                "dbo.ATMTransactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionMoney = c.Double(nullable: false),
                        TransactionTime = c.DateTime(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        BeneficiaryCard = c.String(),
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                        ATMID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.ATMInfoes", t => t.ATMID, cascadeDelete: true)
                .ForeignKey("dbo.UserLogins", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber)
                .Index(t => t.ATMID);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        CountPassword = c.Int(nullable: false),
                        AccountCard_AccountNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.AccountCards", t => t.AccountCard_AccountNumber)
                .Index(t => t.AccountCard_AccountNumber);
            
            CreateTable(
                "dbo.AccountHistories",
                c => new
                    {
                        AccountHistoryID = c.Int(nullable: false, identity: true),
                        AccountHistoryTime = c.DateTime(nullable: false),
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AccountHistoryID)
                .ForeignKey("dbo.UserLogins", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        PersonName = c.String(nullable: false),
                        PersonBirth = c.DateTime(nullable: false),
                        IdCard = c.String(nullable: false),
                        PersonPhone = c.String(nullable: false),
                        PersonAddress = c.String(nullable: false),
                        PersonEmail = c.String(nullable: false),
                        CompanyName = c.String(),
                        Position = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountCards", "PersonID", "dbo.People");
            DropForeignKey("dbo.ATMInfoes", "BankID", "dbo.BankInfoes");
            DropForeignKey("dbo.ATMTransactions", "AccountNumber", "dbo.UserLogins");
            DropForeignKey("dbo.AccountHistories", "AccountNumber", "dbo.UserLogins");
            DropForeignKey("dbo.UserLogins", "AccountCard_AccountNumber", "dbo.AccountCards");
            DropForeignKey("dbo.ATMTransactions", "ATMID", "dbo.ATMInfoes");
            DropForeignKey("dbo.ATMHistories", "ATMID", "dbo.ATMInfoes");
            DropForeignKey("dbo.AccountCards", "BankID", "dbo.BankInfoes");
            DropIndex("dbo.AccountHistories", new[] { "AccountNumber" });
            DropIndex("dbo.UserLogins", new[] { "AccountCard_AccountNumber" });
            DropIndex("dbo.ATMTransactions", new[] { "ATMID" });
            DropIndex("dbo.ATMTransactions", new[] { "AccountNumber" });
            DropIndex("dbo.ATMHistories", new[] { "ATMID" });
            DropIndex("dbo.ATMInfoes", new[] { "BankID" });
            DropIndex("dbo.AccountCards", new[] { "PersonID" });
            DropIndex("dbo.AccountCards", new[] { "BankID" });
            DropTable("dbo.People");
            DropTable("dbo.AccountHistories");
            DropTable("dbo.UserLogins");
            DropTable("dbo.ATMTransactions");
            DropTable("dbo.ATMHistories");
            DropTable("dbo.ATMInfoes");
            DropTable("dbo.BankInfoes");
            DropTable("dbo.AccountCards");
        }
    }
}
