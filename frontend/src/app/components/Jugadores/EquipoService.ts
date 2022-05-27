import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../utils/config.service';

@Injectable()
export class EquipoService {
  constructor(private http: HttpClient, private configService: ConfigService) {}

  getEquiposSofifa() {
    return this.http.get(
      this.configService.SofifaURI + 'get-sofifa-teams/'
    );
  }
}
