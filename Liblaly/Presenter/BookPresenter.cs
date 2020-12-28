using Liblaly.View;
using System;
using System.Collections.Generic;

namespace Liblaly.Presenter {
    public class BookPresenter {
        private readonly Model _model;
        private readonly BookManageView _view;
        public BookPresenter(BookManageView view, Model model) {
            _view = view;
            _model = model;
            _model.MutateBook += Model_MutateBook;
            _view.MutateBook += View_MutateBook;
            _view.SynthesisUniverseBooks(_model.EBooks);
        }

        private void Model_MutateBook(object sender, (int errorCode, List<Book> books) e) => _view.RegenerateBooks(e.books, e.errorCode);

        private void View_MutateBook(object sender, BookArgs e) => _model.MutateBooks(e.Book);
    }
}


