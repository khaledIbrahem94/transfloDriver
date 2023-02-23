import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Drivers } from '../Models/Drivers';
import { ResultSave } from '../Models/Core/ResultSave';
import { IResultForDatatTableDTO } from '../Models/Core/IResultForTable';

@Injectable({
  providedIn: 'root'
})
export class DriversService {
  myURL: string;
  constructor(private httpClient: HttpClient) {
    this.myURL = `${environment.baseUrl}${`Driver/`}`;
  }

  GetAllDrivers(): Observable<IResultForDatatTableDTO<Drivers>> {
    return this.httpClient.get<IResultForDatatTableDTO<Drivers>>(`${this.myURL}GetAllDrivers`);
  }

  GetDriverById(id: number): Observable<ResultSave<Drivers>> {
    return this.httpClient.get<ResultSave<Drivers>>(`${this.myURL}GetDriverById/${id}`);
  }

  InsertDriver(Driver: Drivers): Observable<ResultSave> {
    return this.httpClient.post<ResultSave>(`${this.myURL}InsertDriver`, Driver);
  }

  UpdateDriver(Driver: Drivers): Observable<ResultSave> {
    return this.httpClient.post<ResultSave>(`${this.myURL}UpdateDriver`, Driver);
  }

  DeleteDriver(DriverId: number): Observable<ResultSave> {
    return this.httpClient.delete<ResultSave>(`${this.myURL}DeleteDriver/${DriverId}`);
  }
}
