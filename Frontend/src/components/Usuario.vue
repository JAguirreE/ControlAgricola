<template>
  <section id="usuario">
    <mdb-row>
      <div class="col-md-6 mb-md-0 mb-4">
        <h2 class="secondary-heading mb-3">
          Registrar Usuario
        </h2>

        <p>
          Ingrese los datos solicitados para registrar un usuario
        </p>

        <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1">Nombre</span>
            </div>
            <input
              type="text"
              class="form-control"
              v-model="objUsuario.nombre"
            />
          </div>

          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1">Documento</span>
            </div>
            <input
              type="text"
              class="form-control"
              v-model="objUsuario.documento"
            />
          </div>

          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1">Rol</span>
            </div>
            <select v-model="objUsuario.idRol" class="browser-default custom-select">
              <option></option>
              <option v-for="rol in roles" :key="rol.idRol" :value="rol.idRol">{{ rol.nombre }}</option>
            </select>
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
  name: "Usuario",
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
      objUsuario: {},
      roles: []
    };
  },
  methods: {
    guardar() {
      Services.post("General/RegistrarUsuario", this.objUsuario)
      .then(res => {
        Notifications.success('Registro exitoso');
      })
      .catch(err => {
        console.log(err);
      })
    },

    
  },
  created() {
    Services.get("General/GetRoles")
    .then(res => {
      this.roles = res;
    })
    .catch(err => {
      console.log(err);
    })
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
