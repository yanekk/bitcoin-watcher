namespace BitCoinWatcher.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoinItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountSpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        OfferExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CoinItems");
        }
    }
}
