import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../utils/config.service';

@Injectable()
export class PlantillaService {
  constructor(private http: HttpClient, private configService: ConfigService) {}

  getPlantilla() {
    return this.http.get(
      this.configService.PlantillaURI + 'get-team/'
    );
  }
}
