using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;

namespace ARVIN.MVC.NVolectiy
{
   public class TemplateEngine
    {
        private IContext _context = null;
        private VelocityEngine _velocity = null;
        public TemplateEngine()
        {
            Instance(TemplateConfig.NvelocityFilePath);
        }

        public TemplateEngine(string templatePath)
        {
            Instance(templatePath);
        }

        private void Instance(string templatePath)
        {
            this._velocity = new VelocityEngine();
            var p = new ExtendedProperties();
            p.AddProperty("file.resource.loader.path", templatePath);
            p.AddProperty("input.encoding", "utf-8");
            this._velocity.Init(p);
            this._context = new VelocityContext();
        }

        public string BuildString(string templateFile)
        {
            Template template = this._velocity.GetTemplate(templateFile);
            var writer = new StringWriter();
            template.Merge(this._context, writer);
            return writer.ToString();
        }

        public void Put(string key, object value)
        {
            this._context.Put(key, value);
        }
    }
}
