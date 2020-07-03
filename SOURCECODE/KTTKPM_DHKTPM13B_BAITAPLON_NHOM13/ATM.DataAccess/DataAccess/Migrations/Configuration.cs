namespace DataAccess.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.AtmDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.AtmDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Customers.AddOrUpdate(new Customer() { PersonID = 1, PersonName = "Đỗ Thuỳ Linh", PersonBirth = new DateTime(1999, 05, 21), PersonPhone = "0967247367", PersonAddress = "87/50 đường số 3", PersonEmail = "dothuylinh2105@gmail.com", CompanyName = "A System" });
            context.Customers.AddOrUpdate(new Customer() { PersonID = 2, PersonName = "Lương Thị Thu", PersonBirth = new DateTime(1999, 10, 19), PersonPhone = "0348802311", PersonAddress = "21 Nguyễn Văn Bảo", PersonEmail = "luongthithu@gmail.com", CompanyName = "A System" });
            context.Customers.AddOrUpdate(new Customer() { PersonID = 3, PersonName = "Trương Đăng Quang", PersonBirth = new DateTime(1998, 06, 26), PersonPhone = "0334990937", PersonAddress = "25 Tân Thới Nhất 18", PersonEmail = "truongdangquang1998@gmail.com", CompanyName = "A System" });

            context.Staffs.AddOrUpdate(new Staff() { PersonID = 4, PersonName = "Nguyễn Văn An", PersonBirth = new DateTime(1990, 10, 22), PersonPhone = "0332996060", PersonAddress = "22/34 Gò Vấp", PersonEmail = "nguyenvanan.hagl@gmail.com", Position = Staff.Positions.Tellers });
            context.Staffs.AddOrUpdate(new Staff() { PersonID = 5, PersonName = "Nguyễn Huy Anh", PersonBirth = new DateTime(1995, 01, 15), PersonPhone = "0383838916", PersonAddress = "12 đường số 5, Bình Thạnh", PersonEmail = "nguyenhuyanh.hn@gmail.com", Position = Staff.Positions.Admin });
            context.Staffs.AddOrUpdate(new Staff() { PersonID = 6, PersonName = "Đỗ Trung Quang", PersonBirth = new DateTime(1993, 07, 19), PersonPhone = "0926189299", PersonAddress = "21/12/1 Tân Bình", PersonEmail = "dotrungquang.tqn@gmail.com", Position = Staff.Positions.Tellers });

            context.BankInfos.AddOrUpdate(new BankInfo() { BankID = 1, BankName = "Vietcombank Tân Bình", BankAddress = "25 Tây Thạnh" });
            context.BankInfos.AddOrUpdate(new BankInfo() { BankID = 2, BankName = "Agribank Gò Vấp", BankAddress = "11 Nguyễn Văn Bảo" });
            context.BankInfos.AddOrUpdate(new BankInfo() { BankID = 3, BankName = "VIB Tân Bình", BankAddress = "56 Cộng Hoà" });

            context.ATMInfos.AddOrUpdate(new ATMInfo() { ATMID = 1, ATMName = "AGR 01 Nguyễn Văn Bảo", ATMAddress = "11 Nguyễn Văn Bảo", ATMBalance = 2500000000, BankID = 2 });
            context.ATMInfos.AddOrUpdate(new ATMInfo() { ATMID = 2, ATMName = "VCB 02 Tây Thạnh", ATMAddress = "25 Tây Thạnh", ATMBalance = 500000000, BankID = 1 });
            context.ATMInfos.AddOrUpdate(new ATMInfo() { ATMID = 3, ATMName = "VIB 03 Quang Trung", ATMAddress = "255 Quang Trung", ATMBalance = 150000000, BankID = 3 });

            context.ATMHistories.AddOrUpdate(new ATMHistory() { ATMHistoryTime = DateTime.Now, ATMID = 1 });
            context.ATMHistories.AddOrUpdate(new ATMHistory() { ATMHistoryTime = DateTime.Now, ATMID = 2 });
            context.ATMHistories.AddOrUpdate(new ATMHistory() { ATMHistoryTime = DateTime.Now, ATMID = 3 });

            context.AccountCards.AddOrUpdate(new AccountCard() { AccountNumber = "0711000000001", AccountType = AccountCard.AccountTypes.Visa, CardCreationDate = DateTime.Now, AvailableBalance = 200000, ForeignFee = 3300, InternalFee = 1100, Role = AccountCard.AccountRole.customer, Status = AccountCard.AccountStatus.Start, BankID = 1, PersonID = 1 });
            context.AccountCards.AddOrUpdate(new AccountCard() { AccountNumber = "0710000000002", AccountType = AccountCard.AccountTypes.Normal, CardCreationDate = DateTime.Now, AvailableBalance = 5000000, ForeignFee = 3300, InternalFee = 1100, Role = AccountCard.AccountRole.customer, Status = AccountCard.AccountStatus.Start, BankID = 2, PersonID = 2 });
            context.AccountCards.AddOrUpdate(new AccountCard() { AccountNumber = "0711000000003", AccountType = AccountCard.AccountTypes.Visa, CardCreationDate = DateTime.Now, AvailableBalance = 100000000, ForeignFee = 3300, InternalFee = 1100, Role = AccountCard.AccountRole.staff, Status = AccountCard.AccountStatus.Start, BankID = 3, PersonID = 3 });

            context.UserLogins.AddOrUpdate(new UserLogin() { AccountNumber = "0711000000001", Password = "111111" });
            context.UserLogins.AddOrUpdate(new UserLogin() { AccountNumber = "0710000000002", Password = "222222" });
            context.UserLogins.AddOrUpdate(new UserLogin() { AccountNumber = "0711000000003", Password = "333333" });

            context.AccountHistories.AddOrUpdate(new AccountHistory() { AccountHistoryTime = DateTime.Now, AccountNumber = "0711000000001" });
            context.AccountHistories.AddOrUpdate(new AccountHistory() { AccountHistoryTime = DateTime.Now, AccountNumber = "0710000000002" });
            context.AccountHistories.AddOrUpdate(new AccountHistory() { AccountHistoryTime = DateTime.Now, AccountNumber = "0711000000003" });

            context.ATMTransactions.AddOrUpdate(new ATMTransaction() { TransactionMoney = 12000000, TransactionTime = DateTime.Now, TransactionType = ATMTransaction.TransactionTypes.Payment, BeneficiaryCard = "0711000000001", AccountNumber = "0711000000001", ATMID = 1 });
            context.ATMTransactions.AddOrUpdate(new ATMTransaction() { TransactionMoney = 2000000, TransactionTime = DateTime.Now, TransactionType = ATMTransaction.TransactionTypes.Withdrawl, BeneficiaryCard = "0710000000002", AccountNumber = "0710000000002", ATMID = 2 });
            context.ATMTransactions.AddOrUpdate(new ATMTransaction() { TransactionMoney = 5000000, TransactionTime = DateTime.Now, TransactionType = ATMTransaction.TransactionTypes.Transfer, BeneficiaryCard = "0711000000001", AccountNumber = "0711000000003", ATMID = 3 });

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
