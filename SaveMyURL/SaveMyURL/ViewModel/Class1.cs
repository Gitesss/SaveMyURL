using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveMyURL.Model;
using SaveMyURL.Repositories;

namespace SaveMyURL.ViewModel
{
   public class Class1 : IClass1, ICommand
    {
        private readonly IGroupRepository _groupRepository;

        public Class1(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

       public Class1()
       {
       }

       public void Add()
        {
            Group MojaNowaGrupa = new Group() { Name = "WszystkoINic" };

            _groupRepository.Add(MojaNowaGrupa);
        }

       public bool CanExecute(object parameter)
       {
           throw new NotImplementedException();
       }

       public void Execute(object parameter)
       {
           throw new NotImplementedException();
       }

       public event EventHandler CanExecuteChanged;
    }





    public interface IClass1
    {
        void Add();
    }
}
