using Activity3.Models;
using Activity3.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity3.Services.Business{
    /*
     * Business Service class will pass information from the controller to the appropriate DAO class.
     */
    public class SecurityService{

        //Method used to create a verse. Contains a bibleVere param
        public bool createVerse(BibleVerse bibleVerse){
            SecurityDAO service = new SecurityDAO();
            return service.createVerse(bibleVerse);
        }

        //Method used to retrieve a verse. Pass a BibleVerse param
        public BibleVerse findVerse(BibleVerse bibleVerse) {
            SecurityDAO service = new SecurityDAO();
            return service.findVerse(bibleVerse);
        }

    }
}