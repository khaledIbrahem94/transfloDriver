import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Drivers } from '../../../../Models/Drivers';
import { DriversService } from '../../../../Services/drivers.service';
import { ConfirmationComponent } from '../../../shared/confirmation/confirmation.component';
import { MangeDriversComponent } from '../mange-drivers/mange-drivers.component';

@Component({
  selector: 'app-list-drivers',
  templateUrl: './list-drivers.component.html',
  styleUrls: ['./list-drivers.component.scss']
})
export class ListDriversComponent implements OnInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'phoneNumber', 'actions'];
  dataSource: MatTableDataSource<Drivers> = new MatTableDataSource<Drivers>();

  gettingData = true;
  constructor(private DriversService: DriversService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.GetAllData();
  }

  GetAllData() {
    this.DriversService.GetAllDrivers().subscribe(res => {
      this.gettingData = false;
      if (res.list) {
        this.dataSource.data = [...res.list];
      } 
    });
  }

  editItem(driver: Drivers) {
    const dialogRef = this.dialog.open(MangeDriversComponent, {
      width: '400px',
      panelClass: 'backgroundwhite',
      data: {
        id: driver.id,
      },
    });

    dialogRef.afterOpened().subscribe(() => {
      dialogRef.componentInstance.fromDialog(driver.id);
    });

    this.AfterClose<MangeDriversComponent>(dialogRef, () => {
      this.GetAllData();
    });
  }

  deleteItem(driver: Drivers) {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
      width: '400px',
      data: {
        message: 'Are you sure you want to perform this action?',
      },
    });

    this.AfterClose<ConfirmationComponent>(dialogRef, () => {
      this.DriversService.DeleteDriver(driver.id).subscribe(res => {
        if (res.success) {
          this.GetAllData();
        } else {
          this.snackBar.open(`❌ ${res.message} 111`, 'Close', {
            panelClass: [],
            duration: 3000,
          });
        }
      })
    });
  }

  AfterClose<T>(dialogRef: MatDialogRef<T>, successCallBack: Function) {
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        successCallBack();
      }
    });
  }
}
