namespace MVCShoppingCart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStoreManagerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreManagers", "StoreAddress", c => c.String());
            AddColumn("dbo.StoreManagers", "StoreCity", c => c.String());
            AddColumn("dbo.StoreManagers", "StoreState", c => c.String());
            AddColumn("dbo.StoreManagers", "StoreZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreManagers", "StoreZipCode");
            DropColumn("dbo.StoreManagers", "StoreState");
            DropColumn("dbo.StoreManagers", "StoreCity");
            DropColumn("dbo.StoreManagers", "StoreAddress");
        }
    }
}
