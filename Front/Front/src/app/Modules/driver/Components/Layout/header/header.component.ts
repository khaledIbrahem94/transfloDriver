import { ViewChild } from '@angular/core';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() sidenavToggle = new EventEmitter<void>();
  @ViewChild('sidenav') sidenav!: MatSidenav;

  constructor() { }

  ngOnInit(): void {
  }

  toggleSidenav() {
    this.sidenavToggle.emit();
  }
}
