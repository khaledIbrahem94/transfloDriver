import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DriversService } from '../../../../Services/drivers.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-mange-drivers',
  templateUrl: './mange-drivers.component.html',
  styleUrls: ['./mange-drivers.component.scss']
})
export class MangeDriversComponent implements OnInit {
  DriverForm!: FormGroup;
  Update = false;
  constructor(private fb: FormBuilder, private route: ActivatedRoute, private DriversService: DriversService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.DriverForm = this.fb.group({
      id: ['0'],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: [''],
    });

  }

  fromDialog(id: number) {
    this.Update = true;
    this.DriverForm.disable();
    this.DriversService.GetDriverById(id).subscribe(res => {
      if (res.success) {
        this.DriverForm.enable();
        this.DriverForm.patchValue(res.model!);
      } else {
        this.snackBar.open(`❌ ${res.message}`, 'Close', {
          panelClass: [],
          duration: 3000,
        });
      }
    })
  }

  submitting = false;
  onInsert() {
    if (this.DriverForm.valid) {
      this.submitting = true;
      this.DriversService.InsertDriver(this.DriverForm.value).subscribe(res => {
        this.submitting = false;
        if (res.success) {
          this.DriverForm.reset({id:'0'});
          this.snackBar.open(`✔ ${res.message}`, 'Close', {
            panelClass: [],
            duration: 3000,
          });
        } else {
          this.snackBar.open(`❌ ${res.message}`, 'Close', {
            panelClass: [],
            duration: 3000,
          });
        }
      });
    }
  }
  onUpdate() {
    if (this.DriverForm.valid) {
      this.submitting = true;
      this.DriversService.UpdateDriver(this.DriverForm.value).subscribe(res => {
        this.submitting = false;
        if (res.success) {
          this.DriverForm.reset({id:'0'});
          this.snackBar.open(`✔ ${res.message}`, 'Close', {
            panelClass: [],
            duration: 3000,
          });
        } else {
          this.snackBar.open(`❌ ${res.message}`, 'Close', {
            panelClass: [],
            duration: 3000,
          });
        }
      });
    }
  }
}
