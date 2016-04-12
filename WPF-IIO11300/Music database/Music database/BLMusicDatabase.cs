﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDatabase {
    public class Artist {
        #region PROPERTIES

        private int key;
        public int Key {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string country;
        public string Country {
            get { return country; }
            set { country = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Artist(int key) {
            this.key = key;
        }
        public Artist(int key, string name, string country, int year) {
            this.key = key;
            this.name = name;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }

        public static DataTable GetArtistAlbums(string name) {
            try {
                DataTable artistAlbums = DBMusicDatabase.GetEntity(DBSQLQueries.GetArtistAlbums(), name, "ArtistPage");
                return artistAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetArtists() {
            try {
                DataTable artistTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetArtists(), "Artists");
                return artistTable;
            } catch (Exception ex) {
                throw ex;
            }
        }


        public static bool AddNewArtist(string name, string country, int year) {
            try {
                DBMusicDatabase.AddNewArtist(DBSQLQueries.AddArtist(), name, country, year);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteArtist(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteEntity(DBSQLQueries.DeleteArtist(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool UpdateArtist(int key, string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateEntity(DBSQLQueries.UpdateArtist(), key, name, fill, fill, fill, country, year, fill, fill, int.Parse(fill), fill, fill);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }

        public static List<string> GetComboBoxArtists() {
            try {
                List<string> comboArtists = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxArtists());
                return comboArtists;
            } catch (Exception ex) {
                throw ex;
            } 
        }
        public static DataTable SearchArtist(string srcparam) {
            DataTable resultTable = DBMusicDatabase.SearchTable(DBSQLQueries.SearchArtist(), srcparam, "Result");
            return resultTable;
        }

        #endregion
    }
    public class Album {

        #region PROPERTIES

        private int key;
        public int Key {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string company;
        public string Company {
            get { return company; }
            set { company = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }

        private string imgpath;
        public string Imgpath {
            get { return imgpath; }
            set { imgpath = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Album(int key) {
            this.key = key;
        }
        public Album(int key, string name, string company, int year, string imgpath) {
            this.key = key;
            this.name = name;
            this.company = company;
            this.year = year;
            this.imgpath = imgpath;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }

        public static DataTable GetAlbums() {
            try {
                DataTable albumsTable = DBMusicDatabase.GetEntity(DBSQLQueries.GetAlbums(), "Albums");
                return albumsTable;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetAlbumTracks(string name) {
            try {
                DataTable trackTable = DBMusicDatabase.GetEntity(DBSQLQueries.GetAlbumTracks(), name, "Tracks");
                return trackTable;
            } catch (Exception ex) {
                throw ex;
            }
        }


        public static string GetImageUrl(string album) {
            try {
                string imageUrl = DBMusicDatabase.GetImageUrl(DBSQLQueries.GetImageUrl(), album);
                return imageUrl;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string GetAlbumName(string track) {
            try {
                string albumName = DBMusicDatabase.GetAlbumName(DBSQLQueries.GetAlbumName(), track);
                return albumName;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddAlbum(string name, string artist, string company, int year, string imageLink) {
            try {
                DBMusicDatabase.AddAlbum(DBSQLQueries.AddAlbum(), name, artist, company, year, imageLink);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetAlbumInfo(string album) {
            try {
                List<string> array = DBMusicDatabase.GetAlbumInfo(DBSQLQueries.GetAlbumInfo(), album);
                return array;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteAlbum(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteEntity(DBSQLQueries.DeleteAlbum(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateAlbum(int key, string name, string artist, string company, int year, string imageLink) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateEntity(DBSQLQueries.UpdateAlbum(), key, name, artist, fill, company, fill, year, imageLink, fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetComboBoxAlbums() {
            try {
                List<string> comboAlbums = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxAlbums());
                return comboAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
    public class Track {
        #region PROPERTIES

        private int key;
        public int Key {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string length;
        public string Length {
            get { return length; }
            set { length = value; }
        }

        private string artist;
        public string Artist {
            get { return artist; }
            set { artist = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }

        private string tubepath;
        public string Tubepath {
            get { return tubepath; }
            set { tubepath = value; }
        }

        private int number;
        public int Number {
            get { return number; }
            set { number = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Track(int key) {
            this.key = key;
        }
        public Track(int key, string name, string length, string artist, int year, string tubepath, int number) {
            this.key = key;
            this.name = name;
            this.length = length;
            this.artist = artist;
            this.year = year;
            this.tubepath = tubepath;
            this.number = number;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }
        public static DataTable GetTracks() {
            try {
                DataTable tracksTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetTracks(), "Tracks");
                return tracksTable;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string GetTrackTubepath(string track) {
            try {
                string tubepath = DBMusicDatabase.GetTrackTubepath(DBSQLQueries.GetTrackTubepath(), track);
                return tubepath;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddTrack(string name, string artist, int year, string album, string genre, string link, int number, string length) {
            try {
                string fill = "1";
                DBMusicDatabase.AddEntity(DBSQLQueries.AddTrack(), int.Parse(fill), name, artist, album, fill, fill, year, link, number, length, genre);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteTrack(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteEntity(DBSQLQueries.DeleteTrack(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateTrack(int key, string name, string artist, int year, string album, string link, int number, string length, string genre) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateEntity(DBSQLQueries.UpdateTrack(), key, name, artist, album, fill, fill, year, fill, link, number, length, genre);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }


        #endregion
    }
    public class Genre {
        #region PROPERTIES

        private int key;
        public int Key {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Genre(int key) {
            this.key = key;
        }
        public Genre(int key, string name) {
            this.key = key;
            this.name = name;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }
        public static DataTable GetGenres() {
            try {
                DataTable genresTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetGenres(), "Genres");
                return genresTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddGenre(string name) {
            try {
                string fill = "1";
                DBMusicDatabase.AddEntity(DBSQLQueries.AddGenre(), int.Parse(fill), name, fill, fill, fill, fill, int.Parse(fill), fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteGenre(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteEntity(DBSQLQueries.DeleteGenre(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateGenre(int key, string name) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateEntity(DBSQLQueries.UpdateGenre(), key, name, fill, fill, fill, fill, int.Parse(fill), fill, fill, int.Parse(fill), fill, fill);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }

        public static DataTable GetGenreTracks(string name) {
            try {
                DataTable genreTracks = DBMusicDatabase.GetEntity(DBSQLQueries.GetGenreTracks(), name, "Tracks");
                return genreTracks;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetComboBoxGenres() {
            try {
                List<string> comboGenres = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxGenres());
                return comboGenres;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
    public class Company {
        #region PROPERTIES

        private int key;
        public int Key {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string country;
        public string Country {
            get { return country; }
            set { country = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Company(int key) {
            this.key = key;
        }
        public Company(int key, string name, string country, int year) {
            this.key = key;
            this.name = name;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }
        public static DataTable GetCompanies() {
            try {
                DataTable companiesTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetCompanies(), "Companies");
                return companiesTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddCompany(string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.AddEntity(DBSQLQueries.AddCompany(), int.Parse(fill), name, fill, fill, fill, country, year, fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteCompany(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteEntity(DBSQLQueries.DeleteCompany(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateCompany(int key, string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateEntity(DBSQLQueries.UpdateCompany(), key, name, fill, fill, fill, country, year, fill, fill, int.Parse(fill), fill, fill);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }

        public static DataTable GetCompanyAlbums(string name) {
            try {
                DataTable companyAlbums = DBMusicDatabase.GetEntity(DBSQLQueries.GetCompanyAlbums(), name, "Albums");
                return companyAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetComboBoxCompanies() {
            try {
                List<string> comboCompanies = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxCompanies());
                return comboCompanies;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
    public class Users {
        #region METHODS
        public static DataTable GetUsers() {
            try {
                DataTable users = DBMusicDatabase.GetEntities(DBSQLQueries.GetUsers(), "Users");
                return users;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static bool UpdateUser(int key, string name, bool admin) {
            try {
                DBMusicDatabase.UpdateUser(DBSQLQueries.UpdateUser(), key, name, admin);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool DeleteUser(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteUser(DBSQLQueries.DeleteUser(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;
            } catch (Exception ex) {

                throw ex;
            }
        }

        public static bool UpdatePassword(string username, string password) {
            try {
                DBMusicDatabase.UpdatePassword(DBSQLQueries.UpdatePassword(), username, password);
                return true;
            } catch (Exception ex) {

                throw ex;
            }
        }

        public static List<string> GetComboBoxCountries() {
            try {
                List<string> comboCountries = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxCountries());
                return comboCountries;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetComboBoxYears() {
            try {
                List<string> comboYears = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxYears());
                return comboYears;
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
    #endregion
}
