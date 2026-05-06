using MedicalSystemApp.Models;
using MedicalSystemApp.Services;
using Microsoft.AspNetCore.Mvc;

public class PatientController : Controller
{
    private readonly PatientService _patientService;

    public PatientController()
    {
        _patientService = new PatientService();
    }

    public IActionResult Index()
    {
        var patients = _patientService.GetAllPatients();
        return View(patients);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Patient patient)
    {
        _patientService.AddPatient(patient);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var patient = _patientService.GetPatientById(id);
        return View(patient);
    }

    [HttpPost]
    public IActionResult Edit(Patient patient)
    {
        var existing = _patientService.GetPatientById(patient.Id);

        if (existing != null)
        {
            existing.FullName = patient.FullName;
            existing.Gender = patient.Gender;
            existing.DateOfBirth = patient.DateOfBirth;
            existing.Allergies = patient.Allergies;
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var patient = _patientService.GetPatientById(id);
        return View(patient);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var patient = _patientService.GetPatientById(id);
        if (patient != null)
        {
            _patientService.GetAllPatients().Remove(patient);
        }

        return RedirectToAction("Index");
    }
}