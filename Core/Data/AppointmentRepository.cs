using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAIVeterinariaFinal.Models;
using UAIVeterinariaFinal.Core.Interfaces;

namespace UAIVeterinaria.Core.Data
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        VetDbContext context = new VetDbContext();

        public void Insert(Appointment entity)
        {
            context.Appointments.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();

        }

        public Appointment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> List()
        {
            var Appointment = context.Appointments.ToList();
            foreach (var appo in Appointment)
            {
                appo.Doctor = context.Doctors.FirstOrDefault(d => d.Id == appo.DoctorId);
                appo.Room = context.Rooms.FirstOrDefault(r => r.Id == appo.RoomId);
                appo.Pet = context.Pets.FirstOrDefault(p => p.Id == appo.PetId);
            }
            return Appointment;
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}