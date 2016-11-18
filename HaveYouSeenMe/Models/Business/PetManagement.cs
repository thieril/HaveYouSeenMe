using HaveYouSeenMe.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace HaveYouSeenMe.Models.Business
{
    public class PetManagement
    {

        private  IRepository _repository;

        public PetManagement()
        {
        }

        public PetManagement(IRepository repository)
        {
            _repository = repository;
        }
        public Pet GetByName(string name)
        {
            Pet pet = _repository.GetPetByName(name);
            return pet;
        }

        public void CreateThumbnail(string fileName, string filePath, int thumbWi, int thumbHi, bool maintainAspect)
        {
            // do nothing if original is smaller than the disignated thumbnail dimensions

            var originalFile = Path.Combine(filePath, fileName);
            var source = Image.FromFile(originalFile); //file path above
            if (source.Width <= thumbWi && source.Height <= thumbHi) return; //do nothing



            Bitmap thumbnail;

            try
            {
                int wi = thumbWi;
                int hi = thumbHi;

                if (maintainAspect)
                {
                    //maintain aspect ratio despite the thumbnail size perimeters.  formula to maintain below.

                    if (source.Width > source.Height)
                    {
                        wi = thumbWi;
                        hi = (int)(source.Height * ((decimal)thumbWi / source.Width));
                    }
                    else
                    {
                        hi = thumbHi;
                        wi = (int)(source.Width * ((decimal)thumbHi / source.Height));
                    }

                    thumbnail = new Bitmap(wi, hi);
                    using (Graphics g = Graphics.FromImage(thumbnail)) //instantiate var g as image from thumbnail
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.FillRectangle(Brushes.Transparent, 0, 0, wi, hi); //float x, float y, width, height
                        g.DrawImage(source, 0, 0, wi, hi); //float x, float y, width, height
                    }

                    var thumbnailName = Path.Combine(filePath, "thumbnail_" + fileName);
                    thumbnail.Save(thumbnailName);
                }
            }
            catch
            {
                    
            }



            
        }

    }


}