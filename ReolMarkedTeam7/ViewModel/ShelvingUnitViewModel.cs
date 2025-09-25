using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ReolMarkedTeam7.ViewModel;

public class ShelvingUnitViewModel : BaseViewModel
{
    private Rental _selectedRental;

    public ObservableCollection<Rental> Rentals { get; set; }

    public Rental SelectedRental

    {
        get { return _selectedRental; }
        set
        {
            _selectedRental = value;
            OnPropertyChanged(nameof(SelectedRental));

        }

    }

    public ShelvingUnitViewModel() //Tom constructor til at instantiere ViewModel uden fejl.
    {
        Rentals = new ObservableCollection<Rental>();
    }

    //Dummydata:

    /*public ShelvingUnitViewModel()
    {
        // Dummy-data
        var shelf1 = new ShelvingUnit { ShelvingUnitID = 1, ShelfCount = 4, HasHangerBar = true };
        var shelf2 = new ShelvingUnit { ShelvingUnitID = 2, ShelfCount = 5, HasHangerBar = false };

        var tenant1 = new Tenant { Name = "Hans Hansen" };
        var tenant2 = new Tenant { Name = "Anna Nielsen" };

        Rentals = new ObservableCollection<Rental>
        {
         new Rental(1, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(5), DateTime.Now, 0, 0, tenant1, shelf1),
         new Rental(2, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(8), DateTime.Now, 0, 0, tenant2, shelf2)
        };
    }*/
}