import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { OhmResistance } from 'src/app/Resistors/models/ohm-resistance';

@Injectable
  ({
    providedIn: 'root'
  })
export class ResistorService {

  constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
  }

  public calculateOhmValue(bandAColor: string, bandBColor: string, bandCColor: string, bandDColor: string): Observable<any> {
    return this.http.get <OhmResistance>(this.baseUrl + 'resistor/' + bandAColor + '/' + bandBColor + '/' + bandCColor + '/' + bandDColor);
  }
}

