using Liblaly.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liblaly.Presenter {
    class UserPresenter {
        private readonly Model _model;
        private readonly UserManageView _view;
        public UserPresenter(UserManageView view, Model model) {
            _view = view;
            _model = model;
            _view.SynthesisUniverseUsers(_model.AllUsers, Model.CreationTime);
            _view.UserSeeker += View_UserSeeker;
            _view.TheChosenOne += View_TheChosenOne;
            _view.UserImaginator += View_UserImaginator;
            _view.UserDestroyer += View_UserDestroyer;
            _model.ImaginateUser += Model_MutateUser;
            _model.DestroyUser += Model_DestroyUser;
        }

        

        private void Model_DestroyUser(object sender, (int err, List<User> users) e) {
            if (e.err == -1) {
                _view.SynthesisError("этого пользователя уже нет");
                return;
            }
            _view.SynthesisUniverseUsers(e.users, Model.CreationTime);
        }

        private void Model_MutateUser(object sender, (int err, List<User>users) e) {
            if (e.err == -2) {
                _view.SynthesisError("дата не очень корректна");
                return;
            }
            if (e.err == -1) {
                _view.SynthesisError("этот пользователь уже есть");
                return;
            }
            _view.SynthesisUniverseUsers(e.users, Model.CreationTime);
        }
        private void View_UserDestroyer(object sender, string e) {
            if (e == null) {
                _view.SynthesisError("не хватает данных для уничтожения");
                return;
            }
            _model.DeleteUser(e);
        }
        private void View_UserImaginator(object sender, (string un, string ud) e) {
            if (e.un == null || e.ud == null) {
                _view.SynthesisError("не хватает данных для создания");
                return;
            }
            _model.AddUser(e);
        }

        private void View_TheChosenOne(object sender, string e) {
            if (e == "") {
                return;
            }
            var u = _model.SeekByNameAllUser(e);
            if (u == null) {
                _view.SynthesisError("пользователь с именем " + "\"" + e + "\"" + " не найден");
            } else {
                _view.DrawUser(u); 
            }
        }

        private void View_UserSeeker(object sender, string e) {
            if (e == "") {
                _view.SynthesisUniverseUsers(_model.AllUsers, Model.CreationTime);
            } else {
                _view.SynthesisUniverseUsers(_model.SeekByNameAllUsers(e), Model.CreationTime);
            }
        }
    }
}
