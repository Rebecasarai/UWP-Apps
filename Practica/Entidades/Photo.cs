using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Photo
    {
        private int _albumId;
        private int _id;
        private String _title;
        private String _url;
        private String _thumbnailUrl;

        public Photo(int albumId, int id, string title, string url, string thumbnailUrl)
        {
            _albumId = albumId;
            _id = id;
            _title = title;
            _url = url;
            _thumbnailUrl = thumbnailUrl;
        }

        public int albumId
        {
            get
            {
                return _albumId;
            }
            set
            {
                _albumId = value;
            }
        }


        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }



        public String title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }


        public String url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        public String thumbnailUrl
        {
            get
            {
                return _thumbnailUrl;
            }
            set
            {
                _thumbnailUrl = value;
            }
        }

    }

}
