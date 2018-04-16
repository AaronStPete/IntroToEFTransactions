namespace BankingTransactionRedux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingQuery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(),
                        Action = c.String(),
                        AccountNumber = c.String(),
                        AmountChanged = c.Decimal(precision: 18, scale: 2),
                        NewAmount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
