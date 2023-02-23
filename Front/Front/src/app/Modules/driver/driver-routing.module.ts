import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './Components/landing-page/landing-page.component';
import { ListDriversComponent } from './Components/list-drivers/list-drivers.component';
import { MangeDriversComponent } from './Components/mange-drivers/mange-drivers.component';

const routes: Routes = [{
  path: '',
  component: LandingPageComponent,
  children: [
    {
      path: '',
      component: ListDriversComponent
    },
    {
      path: 'Mange',
      component: MangeDriversComponent
    },
  ]
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriverRoutingModule { }
