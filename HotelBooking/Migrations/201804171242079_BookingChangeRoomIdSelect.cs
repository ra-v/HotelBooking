namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingChangeRoomIdSelect : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "SelectedRoomId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "SelectedRoomId");
        }
    }
}
