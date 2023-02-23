import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements OnInit {
  @ViewChild('sideNav') sideNav!: MatSidenav;

  constructor() { }

  ngOnInit(): void {
  }

  toggleSidenav() {
    this.sideNav.toggle();
  }
}
