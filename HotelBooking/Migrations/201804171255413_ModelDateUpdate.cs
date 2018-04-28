namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelDateUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "StartDate", c => c.String());
            AlterColumn("dbo.Bookings", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
