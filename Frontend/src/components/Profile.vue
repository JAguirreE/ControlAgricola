<template>
  <section id="profile">
    <mdb-row>
      <div class="col-md-6 mb-md-0 mb-4">
        <h2 class="secondary-heading mb-3">
          Registrar Actividad
        </h2>

        <p>
          Ingrese los datos solicitados para registrar una actividad en el lote
        </p>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Lote</span>
          </div>
            <select  v-model="objActividad.idLote" class="browser-default custom-select">
              <option />
              <option
                v-for="lote in lotes"
                :key="lote.idLote"
                :value="lote.idLote"
              >{{ lote.nombre }}</option>
            </select>
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Agricultor</span>
          </div>
            <select  v-model="objActividad.idUsuario" class="browser-default custom-select">
              <option />
              <option
                v-for="usuario in usuarios"
                :key="usuario.idUsuario"
                :value="usuario.idUsuario"
              >{{ usuario.nombre }}</option>
            </select>
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Tipo de actividad</span>
          </div>
            <select  v-model="objActividad.idTipoActividad" @change="getProductosActividad" class="browser-default custom-select">
              <option />
              <option
                v-for="tipoActividad in tiposActividad"
                :key="tipoActividad.idTipo"
                :value="tipoActividad.idTipo"
              >{{ tipoActividad.nombre }}</option>
            </select>
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Producto utilizado</span>
          </div>
          <select v-model="objActividad.idProducto" class="browser-default custom-select">
            <option selected />
            <option
              v-for="producto in productos"
              :key="producto.idProducto"
              :value="producto.idProducto"
            >{{ producto.nombre }}</option>
          </select>
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Cantidad</span>
          </div>
          <input
            type="number"
            class="form-control"
            placeholder="Ej: 2 lb o 30 l/h (Litros/Hectarea)"
            v-model="objActividad.cantidad"
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Método aplicación</span>
          </div>
          <input
            type="text"
            class="form-control"
            placeholder="Ej: Manual, Maquina o Al Voleo"
            v-model="objActividad.metodoAplicacion"
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Meteorología</span>
          </div>
          <input
            type="text"
            class="form-control"
            placeholder="Ej: Lluvioso, Sequía o Nevado"
            v-model="objActividad.meteorologia"
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Foto</span>
          </div>
          <div class="custom-file">
            <input type="file" class="custom-file-input" id="inputGroupFile01" aria-describedby="inputGroupFileAddon01">
            <label class="custom-file-label" for="inputGroupFile01">Seleccione la foto...</label>
          </div>
        </div>

        <div class="input-group mb-3">
            <mdb-btn color="primary" @click="guardar">Guardar</mdb-btn>
          </div>

      </div>
    </mdb-row>
  </section>
</template>

<script>
import {
  mdbRow,
  mdbCol,
  mdbCard,
  mdbCardBody,
  mdbView,
  mdbMask,
  mdbCardTitle,
  mdbCardText,
  mdbCardFooter,
  mdbIcon,
  mdbBtn,
  mdbPagination,
  mdbPageNav,
  mdbPageItem
} from "mdbvue";

import { Services, Notifications } from "../index";

export default {
  name: "Profile",
  components: {
    mdbRow,
    mdbCol,
    mdbCard,
    mdbCardBody,
    mdbView,
    mdbMask,
    mdbCardTitle,
    mdbCardText,
    mdbCardFooter,
    mdbIcon,
    mdbBtn,
    mdbPagination,
    mdbPageNav,
    mdbPageItem
  },
  data() {
    return {
      objActividad: {},
      tiposActividad: [],
      productos: [],
      lotes: [],
      usuario: [],
    };
  },
  methods: {
    guardar() {
      this.objActividad.foto = "tomate.jpg";
      this.objActividad.idPermiso = 1;
      this.objActividad.fecha = new Date();
      Services.post("General/RegistrarActividad", this.objActividad)
      .then(res => {
        Notifications.success('Registro exitoso');
      })
      .catch(err => {
        console.log(err);
      })
    },

    getTiposActividad() {
      Services.get("General/GetTiposActividad")
          .then(res => {
            this.tiposActividad = res;
          })
          .catch(err => {
            console.log(err);
          });
    },

    getProductosActividad() {
      Services.get("General/GetProductosActividad", { idTipo: this.objActividad.idTipoActividad })
        .then(res => {
          this.productos = res;
        })
        .catch(err => {
          console.log(err);
        });
    },

    getProductos() {
      Services.get("General/GetProductos")
        .then(res => {
          this.productos = res;
        })
        .catch(err => {
          console.log(err);
        });
    },

    getLotes() {
      Services.get("General/GetLotes")
        .then(res => {
          this.lotes = res;
        })
        .catch(err => {
          console.log(err);
        });
    },

    getUsuarios() {
      Services.get("General/GetUsuarios")
        .then(res => {
          this.usuarios = res;
        })
        .catch(err => {
          console.log(err);
        });
    },
  },
  mounted() {
    this.getLotes();
    this.getUsuarios();
    this.getTiposActividad();
  }
};
</script>

<style scoped>
.profile-card-footer {
  background-color: #f7f7f7 !important;
  padding: 1.25rem;
}
.card.card-cascade .view {
  box-shadow: 0 3px 10px 0 rgba(0, 0, 0, 0.15), 0 3px 12px 0 rgba(0, 0, 0, 0.15);
}
</style>
