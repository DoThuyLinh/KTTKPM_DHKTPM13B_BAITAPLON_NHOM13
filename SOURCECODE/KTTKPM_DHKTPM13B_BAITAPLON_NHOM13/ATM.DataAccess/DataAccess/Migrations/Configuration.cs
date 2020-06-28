namespace DataAccess.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            context.Customers.Add(new Customer("Đỗ Thuỳ Linh", new DateTime(1999, 05, 21), "0967247367", "87/50 đường số 3", "dothuylinh2105@gmail.com", "A System"));
            context.Customers.Add(new Customer("Lương Thị Thu", new DateTime(1999, 10, 19), "0348802311", "21 Nguyễn Văn Bảo", "luongthithu@gmail.com", "A System"));
            context.Customers.Add(new Customer("Trương Đăng Quang", new DateTime(1998, 06, 26), "0334990937", "25 Tân Thới Nhất 18", "truongdangquang1998@gmail.com", "A System"));
            context.SaveChanges();

            context.Staffs.Add(new Staff("Nguyễn Văn An", new DateTime(1990, 10, 22), "0332996060", "22/34 Gò Vấp", "nguyenvanan.hagl@gmail.com", Staff.Positions.Tellers));
            context.Staffs.Add(new Staff("Nguyễn Huy Anh", new DateTime(1995, 01, 15), "0383838916", "12 đường số 5, Bình Thạnh", "nguyenhuyanh.hn@gmail.com", Staff.Positions.Admin));
            context.Staffs.Add(new Staff("Đỗ Trung Quang", new DateTime(1993, 07, 19), "0926189299", "21/12/1 Tân Bình", "dotrungquang.tqn@gmail.com", Staff.Positions.Tellers));
            context.SaveChanges();

            context.BankInfos.Add(new BankInfo("Vietcombank Tân Bình", "25 Tây Thạnh"));
            context.BankInfos.Add(new BankInfo("Agribank Gò Vấp", "11 Nguyễn Văn Bảo"));
            context.BankInfos.Add(new BankInfo("VIB Tân Bình", "56 Cộng Hoà"));
            context.SaveChanges();

            context.ATMInfos.Add(new ATMInfo("AGR 01 Nguyễn Văn Bảo", "11 Nguyễn Văn Bảo", 2500000000, 2));
            context.ATMInfos.Add(new ATMInfo("VCB 02 Tây Thạnh", "25 Tây Thạnh", 500000000, 1));
            context.ATMInfos.Add(new ATMInfo("VIB 03 Quang Trung", "255 Quang Trung", 150000000, 3));
            context.SaveChanges();

            context.ATMHistories.Add(new ATMHistory(DateTime.Now, 1));
            context.ATMHistories.Add(new ATMHistory(DateTime.Now, 2));
            context.ATMHistories.Add(new ATMHistory(DateTime.Now, 3));
            context.SaveChanges();

            context.AccountCards.Add(new AccountCard("0711000000001", AccountCard.AccountTypes.Visa, DateTime.Now, 200000, 3300, 1100, AccountCard.AccountRole.customer, AccountCard.AccountStatus.Start, 1, 1));
            context.AccountCards.Add(new AccountCard("0710000000002", AccountCard.AccountTypes.Normal, DateTime.Now, 5000000, 3300, 1100, AccountCard.AccountRole.customer, AccountCard.AccountStatus.Start, 2, 2));
            context.AccountCards.Add(new AccountCard("0711000000003", AccountCard.AccountTypes.Visa, DateTime.Now, 100000000, 3300, 1100, AccountCard.AccountRole.staff, AccountCard.AccountStatus.Start, 3, 3));
            context.SaveChanges();

            context.UserLogins.Add(new UserLogin("0711000000001", "111111"));
            context.UserLogins.Add(new UserLogin("0710000000002", "222222"));
            context.UserLogins.Add(new UserLogin("0711000000003", "333333"));
            context.SaveChanges();

            context.AccountHistories.Add(new AccountHistory(DateTime.Now, "0711000000001"));
            context.AccountHistories.Add(new AccountHistory(DateTime.Now, "0710000000002"));
            context.AccountHistories.Add(new AccountHistory(DateTime.Now, "0711000000003"));
            context.SaveChanges();

            context.ATMTransactions.Add(new ATMTransaction(12000000, DateTime.Now, ATMTransaction.TransactionTypes.Payment, "0711000000001", "0711000000001", 1));
            context.ATMTransactions.Add(new ATMTransaction(2000000, DateTime.Now, ATMTransaction.TransactionTypes.Withdrawl, "0710000000002", "0710000000002", 2));
            context.ATMTransactions.Add(new ATMTransaction(5000000, DateTime.Now, ATMTransaction.TransactionTypes.Transfer, "0711000000001", "0711000000003", 3));
            context.SaveChanges();
        }
    }
}
