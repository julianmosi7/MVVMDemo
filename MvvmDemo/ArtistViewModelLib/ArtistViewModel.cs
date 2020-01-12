using ArtistModelLib;
using MVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArtistViewModelLib
{
    public class ArtistViewModel : ObservableObject
    {
        public ArtistViewModel()
        {

        }

        private ModelContext db;

        public ArtistViewModel(ModelContext db)
        {
            this.db = db;
            Artists = db.Artists.AsObservableCollection();
            SelectedArtist = Artists.First().Name;
        }

        public ObservableCollection<Artist> Artists { get; private set; }

        private string newArtist = "new";

        public string NewArtist
        {
            get => newArtist;
            set
            {
                newArtist = value;
                RaisePropertyChangedEvent(nameof(NewArtist));
            }
        }

        private string selectedArtist;

        public string SelectedArtist
        {
            get => selectedArtist;
            set
            {
                selectedArtist = value;
                Songs = Artists.
                    First(x => x.Name == selectedArtist)
                    .Songs;
                RaisePropertyChangedEvent(nameof(SelectedArtist));
            }
        }

        private List<Song> songs;

        public List<Song> Songs
        {
            get => songs;
            set
            {
                songs = value;
                RaisePropertyChangedEvent(nameof(Songs));
            }

        }

        public ICommand AddCommand => new RelayCommand<string>(
            DoAddArtist,
            x => NewArtist.Trim().Length > 0
            );

        private void DoAddArtist(string obj)
        {
            Artists.Add(new Artist { Name = NewArtist });
            NewArtist = "";
        }
    }
}
