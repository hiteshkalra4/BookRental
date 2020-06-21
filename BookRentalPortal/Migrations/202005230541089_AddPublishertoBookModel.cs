namespace BookRentalPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublishertoBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Publisher", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Publisher");
        }
    }
}
