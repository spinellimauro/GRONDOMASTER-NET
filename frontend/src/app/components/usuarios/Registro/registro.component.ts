import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Equipo } from "src/app/models/Equipo";
import { ConfigService } from "src/app/utils/config.service";
import { EquipoService } from "../../Jugadores/EquipoService";
import { UsuariosService } from "../usuarioService";

@Component({
  templateUrl: "registro.component.html",
  styleUrls: ["registro.component.scss"],
})
export class RegistroComponent implements OnInit {
  usuario: FormGroup;

  public Validaciones: {
    Users: {
      Nombre: string;
      Apellido: string;
      Email: string;
      Password: string;
      PasswordMinLength: string;
      PasswordMaxLength: string;
      PasswordSpecific: string;
      Equipo: string;
    };
    ValidacionContrasenaNueva: string[];
  };

  public Etiquetas: {
    Users: {
      Datos: string;
      Habilitacion: string;
    };
    Registrarse: string;
    Seleccione: string;
  };

  selectedTeam: any = null;

  teams: any[];

  constructor(
    private fb: FormBuilder,
    private usuariosService: UsuariosService,
    private equiposService: EquipoService,
    public configService: ConfigService,
    private toastService: ToastrService,
    private router: Router
  ) {
    this.usuario = this.fb.group({
      id: ["0"],
      nombre: ["", [Validators.required]],
      apellido: ["", [Validators.required]],
      email: ["", [Validators.required, Validators.email]],
      password: [
        "",
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(30),
        ],
      ],
      equipo: [, [Validators.required]],
    });
  }

  ngOnInit() {
    this.Etiquetas = {
      Users: {
        Datos: this.configService.etiquetas.Users.Datos,
        Habilitacion: this.configService.etiquetas.Users.Habilitacion,
      },
      Registrarse: this.configService.etiquetas.Register,
      Seleccione: this.configService.etiquetas.Seleccione,
    };

    this.Validaciones = {
      Users: {
        Nombre: this.configService.validaciones.Users.Nombre,
        Apellido: this.configService.validaciones.Users.Apellido,
        Email: this.configService.validaciones.Users.Email,
        Password: this.configService.validaciones.Users.Password,
        PasswordMinLength:
          this.configService.validaciones.Users.PasswordMinLength,
        PasswordMaxLength:
          this.configService.validaciones.Users.PasswordMaxLength,
        PasswordSpecific:
          this.configService.validaciones.Users.PasswordSpecific,
        Equipo: this.configService.validaciones.Users.Equipo,
      },
      ValidacionContrasenaNueva:
        this.configService.validaciones.ValidacionContrasenaNueva,
    };

    this.equiposService.getEquiposSofifa().subscribe((data: Equipo[]) => {
      data.forEach(team => {
        team.urlImage = "https://cdn.sofifa.com/teams/" + team.idSoFifa + "/30.png"
      });
      console.log(data);
      this.teams = data;
    });
  }

  guardar() {
    const model = this.usuario.getRawValue();
    console.log(model);

    this.usuariosService.createUsuario(model).subscribe((data) => {
      this.toastService.success(
        this.configService.mensajes.AUsuario,
        this.configService.mensajes.TituloSuccess
      );
      this.router.navigateByUrl("login");
    });
  }

  compareFn(c1: any, c2: any): boolean {
    return c1 && c2 ? c1.id === c2.id.toString() : c1 === c2;
  }
}
