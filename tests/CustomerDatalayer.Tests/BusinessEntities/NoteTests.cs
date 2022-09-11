using CustomerDatalayer.BusinessEntities;
using System;
using System.Collections.Generic;

namespace CustomerDatalayer.Tests.BusinessEntities
{
    public class NoteTests
    {
        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            Note note = new Note()
            {
                CustomerId = 1,
                NoteRecord = "test note",
            };
            Assert.NotNull(note);
            Assert.Equal(1, note.CustomerId);
            Assert.Equal("test note", note.NoteRecord);
        }

    }
}
