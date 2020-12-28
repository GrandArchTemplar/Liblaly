using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liblaly.Presenter {
    class SavePresenter {
        private readonly Model _model;
        private readonly MainWindow _view;
        public SavePresenter(MainWindow view, Model model) {
            _view = view;
            _model = model;
            _view.Save += View_Save;
        }

        private void View_Save(object sender, EventArgs e) {
            _model.SaveAll();
        }
    }
}
