import { BrowserModule } from '@angular/platform-browser';
import {
  NgModule,
  APP_INITIALIZER,
  ErrorHandler,
  LOCALE_ID,
} from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConfigService } from './utils/config.service';
import { UsuariosService } from './components/usuarios/usuarioService';
import { UsuarioDialog } from './dialogs/usuario/usuario.dialog';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {
  FormsModule,
  Validators,
  FormControl,
  FormBuilder,
  ReactiveFormsModule,
} from '@angular/forms';
import { MaterialModule } from './utils/material.module';
import { PrimeNGModule } from './utils/primeng.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrService, ToastrModule } from 'ngx-toastr';
import { TableModule } from 'primeng/table';
import { AppErrorHandler } from './utils/error.service';
import { LoggedGuard } from './utils/logged.guard';
import { LoggedService, getToken } from './utils/logged.service';
import { LoginComponent } from './components/usuarios/Login/login.component';
import { ConfirmarEmailComponent } from './components/usuarios/confirmacion-contrasena/confirmar-email.component';
import { JwtModule } from '@auth0/angular-jwt';
// import { registerLocaleData, LocationStrategy, HashLocationStrategy } from '@angular/common';
// import localeEsAr from '@angular/common/locales/es-AR';
// import localeEsArExtra from '@angular/common/locales/extra/es-AR';
import { CambiarContrasenaComponent } from './components/usuarios/cambiarcontrasena/cambiarcontrasena.component';
import { OlvidoContrasenaDialog } from './components/usuarios/olvido-contrasena/olvido-contrasena.dialog';
import { AuthInterceptor } from './utils/auth.interceptor';
import { SearchJugadoresComponent } from './components/mercado/searchJugadores/searchJugadores.component';
import { EquipoComponent } from './components/Jugadores/Equipo/equipos.component';
import { UsuariosComponent } from './components/usuarios/usuarios/usuarios.component';
import { JugadorService } from './components/mercado/jugadorService';
import { PlantillaService } from './components/Jugadores/plantillaService';
import { UtilService } from './utils/util.service';
import { RegistroComponent } from './components/usuarios/Registro/registro.component';
import {
  SpinnerComponent,
  SpinnerInterceptor,
  SpinnerService,
} from './components/spinner/spinner.component';
import { EquipoService } from './components/Jugadores/EquipoService';

// registerLocaleData(localeEsAr, localeEsArExtra)

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ConfirmarEmailComponent,
    UsuariosComponent,
    SearchJugadoresComponent,
    EquipoComponent,
    CambiarContrasenaComponent,
    UsuarioDialog,
    OlvidoContrasenaDialog,
    RegistroComponent,
    SpinnerComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialModule,
    PrimeNGModule,
    TableModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      closeButton: true,
    }), // ToastrModule added
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        whitelistedDomains: ['localhost:8080'],
      },
    }),
  ],
  entryComponents: [
    LoginComponent,
    ConfirmarEmailComponent,
    UsuarioDialog,
    UsuariosComponent,
    RegistroComponent,
    SearchJugadoresComponent,
    EquipoComponent,
    CambiarContrasenaComponent,
    OlvidoContrasenaDialog,
  ],

  providers: [
    LoggedService,
    LoggedGuard,
    ConfigService,
    ToastrService,
    FormControl,
    FormBuilder,
    Validators,
    UsuariosService,
    JugadorService,
    PlantillaService,
    EquipoService,
    UtilService,
    SpinnerService,
    { provide: LOCALE_ID, useValue: 'es-AR' },
    // { provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: ErrorHandler, useClass: AppErrorHandler },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SpinnerInterceptor,
      multi: true,
    },
    {
      provide: APP_INITIALIZER,
      useFactory: (config: ConfigService) =>
        function () {
          return config.readData();
        },
      deps: [ConfigService],
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
