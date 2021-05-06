import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { Funcionario } from '../models/Funcionario';
import { FuncionarioService } from './funcionario.service';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit{

  public funcionarioForm: FormGroup;
  public titulo = 'Funcionarios';
  public funcionarios: Funcionario[] = [];
  public funcionarioSelecionado: Funcionario;
  public modo = 'post';
  public escalaList: string[] = [];
  public mes : number;
  public dias  : number;
  public mesSelecionado : any;


  //5x2, 6x1, 6x2 e 12x36.
  constructor(
              private funcionarioService: FuncionarioService,
              public router : Router,
              private fb: FormBuilder){
              this.criarForm();
              this.escalaList = ["5x2", "6x1","6x2", "12x36"];

  };

  ngOnInit() {
    this.carregarFuncionario();
  };

  criarForm(){
    this.funcionarioForm = this.fb.group({
      id: [''],
      nome: ['',Validators.required],
      escala: ['', Validators.required],
      custoDia: ['', Validators.required]
    });
  };

  funcionarioSubmit(){
    this.salvarFuncionario(this.funcionarioForm.value);
    this.voltarPage();
  };

  salvarFuncionario(funcionario: Funcionario){
    (funcionario.id === 0) ? this.modo = 'post' : this.modo = 'put';

    this.funcionarioService[this.modo](funcionario).subscribe(
      (retorno: Funcionario) => {
        console.log(retorno);
        this.carregarFuncionario();
    },
    (erro: any) => {
      console.log(erro);
      console.log("Erro na função salvar funcionario");
     }
    );
  }

  voltar(){
    this.funcionarioSelecionado = null;
  };

  voltarPage(){
    this.router.navigate(['/funcionarios']);
  }

  funcionarioNovo(){
    this.funcionarioSelecionado = new Funcionario();
    this.funcionarioForm.patchValue(this.funcionarioSelecionado);
  };

  funcSelect(funcionario: Funcionario){
    this.funcionarioSelecionado = funcionario;
    this.funcionarioForm.patchValue(funcionario);
  };

  funcionarioExcluir(id: number){
    this.funcionarioService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarFuncionario();
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  public carregarFuncionario(){
    this.funcionarioService.getAll().subscribe(
      (funcionarios: Funcionario[]) => {
        this.funcionarios = funcionarios;
        if (this.funcionarios != null) {
          this.calculaCusto ();
        }
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  public calculaCusto (param2?){

    if (param2 == '') {
      var dias = this.calculaDiasTrabalhados(5, 2021);
      //console.log(param2);
    }else {
      var dias = this.calculaDiasTrabalhados(param2, 2021);
      //console.log(param2);
    };

    var anoBissexto = [28, 29];
    var isBissexto = anoBissexto.includes(dias);
    for (let index = 0; index < this.funcionarios.length; index++) {
      var escala = this.funcionarios[index].escala;
      let diasTrabalhados = 0;
      //28, 30, 31
      switch (escala) {
        case "5x2" :
          diasTrabalhados = (isBissexto ? 20 : dias == 30 ? 22 : 23);
          this.funcionarios[index].custoMensal = this.funcionarios[index].custoDia * diasTrabalhados;
        break;
        case "6x1":
          diasTrabalhados = (isBissexto ? 24 : dias == 30 ? 26 : 27);
          this.funcionarios[index].custoMensal = this.funcionarios[index].custoDia * diasTrabalhados;
        break;
        case "6x2":
          diasTrabalhados = (isBissexto ? 20 : dias == 30 ? 22 : 23);
          this.funcionarios[index].custoMensal = this.funcionarios[index].custoDia * diasTrabalhados;
        break;
          default:
            diasTrabalhados = (isBissexto ? 20 : dias == 30 ? 22 : 23);
            this.funcionarios[index].custoMensal = this.funcionarios[index].custoDia * diasTrabalhados;
        break;
      }
    }
  }

  public calculaDiasTrabalhados (mes: any, year : any){

        return new Date(year, mes, 0).getDate();

  }

  public atualizaTabela(novoValor){
    //console.log(parseInt(novoValor));
    this.calculaCusto(parseInt(novoValor));
  }

  public meses = [
    { id: 1,  name: "Janeiro"  },
    { id: 2,  name: "Fevereiro"},
    { id: 3,  name: "Março"    },
    { id: 4,  name: "Abril"    },
    { id: 5,  name: "Maio"     },
    { id: 6,  name: "Junho"    },
    { id: 7,  name: "Julho"    },
    { id: 8,  name: "Agosto"   },
    { id: 9,  name: "Setembro" },
    { id: 10, name: "Outubro"  },
    { id: 11, name: "Novembro" },
    { id: 12, name: "Dezembro" },
];
}
