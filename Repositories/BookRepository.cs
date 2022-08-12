using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories;

public class BookRepository : IBookRepository
{
    private readonly SqlConnection _context;
    public BookRepository(SqlConnection context)
    {
        _context = context;
    }

    public async Task<Book?> GetBookByRoomIdAndBetweenDateStartAndDateEnd(Guid roomId, DateTime dateStart, DateTime dateEnd)
    {
        return await _context.QueryFirstOrDefaultAsync<Book?>(
             "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
             new
             {
                 Room = roomId,
                 DateStart = dateStart,
                 DateEnd = dateEnd,
             });
    }
}


//var room = await connection.QueryFirstOrDefaultAsync<Book?>(
//            "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
//            new
//            {
//                Room = command.RoomId,
//                DateStart = command.Day.Date,
//                DateEnd = command.Day.Date.AddDays(1).AddTicks(-1),
//            });