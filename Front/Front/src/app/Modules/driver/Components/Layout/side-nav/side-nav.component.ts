import { Component, OnInit, EventEmitter, Output, ViewChild } from '@angular/core';
import { MatDrawerMode, MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  @ViewChild('sidenav') sidenav!: MatSidenav;
  @Output() closeSidenav = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  mode: MatDrawerMode = "side";
  opened: boolean = false;

  closeNav() {
    this.opened = false;
    this.closeSidenav.emit();
  }

  toggleSidenav() {
    this.opened = !this.opened;
    this.sidenav.toggle();
  }
}
