using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InventoryAPP.Models;

namespace InventoryAPP.Controllers
{
    public class AssetsController : ApiController
    {
        private InventoryControlManagementEntities1 db = new InventoryControlManagementEntities1();

        // GET: api/Assets
        public IQueryable<Asset> GetAssets()
        {
            return db.Assets;
        }        

        // GET: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult GetAsset(int id)
        {
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }
        public class NewAsset
        {
            public NewAsset(string s)
            {
                AssetId = s;
            }
            public string AssetId { get; set; }
        }

        public IQueryable<NewAsset> GetAssetsAddedLastMonth()
        {
            DateTime compareDate = DateTime.Now.AddMonths(-1);
            List<NewAsset> assets = new List<NewAsset>();
            var query = from x in db.Assets
                        where x.DateOfPurchase > compareDate
                        orderby x.AssetID ascending
                        select x;
            foreach (var i in query)
            {
                NewAsset newAsset = new NewAsset(i.AssetID.ToString());
                assets.Add(newAsset);
            }
            return assets.AsQueryable<NewAsset>();
        }

        public class AssetDetails
        {
            public AssetDetails(string model, string serial, string brandname)
            {
                modelnumber = model;
                serialnumber = serial;
                brand = brandname;
            }
            public string brand { get; set; }
            public string modelnumber { get; set; }
            public string serialnumber { get; set; }
        }

        public IQueryable<AssetDetails> GetAssetsByUserID(string id)
        {
            List<AssetDetails> assets = new List<AssetDetails>();
            var query = from t in db.Assets
                        join o in db.UserAssets
                        on t.AssetID equals o.AssetID
                        where o.EmailID == id
                        select new
                        {
                            modelnumber = t.Model,
                            serialnumber = t.SerialNo,
                            brandname = t.Brand
                        };
            foreach (var i in query)
            {
                AssetDetails newAsset = new AssetDetails(i.modelnumber.ToString(), i.serialnumber.ToString(), i.brandname.ToString());
                assets.Add(newAsset);
            }
            return assets.AsQueryable<AssetDetails>();
        }
        // PUT: api/Assets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsset(int id, Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asset.AssetID)
            {
                return BadRequest();
            }

            db.Entry(asset).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Assets
        [ResponseType(typeof(Asset))]
        public IHttpActionResult PostAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assets.Add(asset);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asset.AssetID }, asset);
        }

        // DELETE: api/Assets/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult DeleteAsset(int id)
        {
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            db.Assets.Remove(asset);
            db.SaveChanges();

            return Ok(asset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetExists(int id)
        {
            return db.Assets.Count(e => e.AssetID == id) > 0;
        }
    }
}