using Liblaly.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liblaly.Presenter {
    class UserBookPresenter {
        private readonly Model _model;
        private readonly UserBookManageView _view;
        public UserBookPresenter(UserBookManageView view, Model model) {
            _view = view;
            _model = model;
            _view.TheChosenOneUser += View_TheChosenOne;
            _view.SynthesisUniversalUser(model.EUsers);
            _view.BookSeeker += View_BookSeeker;
            _view.TransferBook += View_TransferBook;
            _view.UserSeeker += View_UserSeeker;
            _model.MutateBook += Model_MutateBook;
        }

        private void View_UserSeeker(object sender, string e) {
            if (e == "") {
                _view.ImaginateUsers(_model.EUsers);
            } else {
                _view.ImaginateUsers(_model.SeekByNameEUsers(e));
            }
        }

        private void Model_MutateBook(object sender, (int errorCode, List<Book> books) e) {
            if (e.errorCode != 0) {
                _view.SynthesisError(e.errorCode == -2 ? "попытка создать отрицательное число книг" : "отобрали слишком много книг");
            } else {
                _view.RefreshLibBook(e.books);
            }
        }



        private void View_TransferBook(object sender, (bool isToLib, string bookName, string userName) e) {
            _model.MutateBooks(new Book(e.bookName, e.isToLib ? 1 : -1));
            (int err, List<Book> ubooks) = e.isToLib
                ? _model.ExtractBookFromUser(e.userName, e.bookName)
                : _model.InsertBookToUser(e.userName, e.bookName);
            if (0 != err) {
                _view.SynthesisError(err == -2 ? "попытка создать отрицательное число книг" : "отобрали слишком много книг");
            } else {
                _view.RefreshUserBook(ubooks);
            }

        }

        private void View_BookSeeker(object sender, string e) {
            if (e == "") {
                _view.ImaginateBooks(_model.EBooks);
            } else {
                _view.ImaginateBooks(_model.SeekByNameEBook(e));
            }
        }

        private void View_TheChosenOne(object sender, string e) {
            var u = _model.SeekByNameEUser(e);
            if (null == u) {
                _view.SynthesisError("пользователь с именем " + "\"" + e + "\"" + " не найден");
            } else {
                _view.ImaginateUser(u);
            }
        }
    }
}
