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

        <section class="section-preview">
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1">@</span>
            </div>
            <select>
              <option />
              <option
                v-for="tipoActividad in tiposActividad"
                :key="tipoActividad.idTipoActividad"
                :value="tipoActividad.idTipoActividad"
              >{{ tipoActividad.idTipoActividad }}</option>
            </select>
            <input
              type="text"
              class="form-control"
              placeholder="Username"
              v-model="actividad.idTipoActividad"
            />
          </div>
        </section>
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

import { Services } from "../index";

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
      actividad: {}
    };
  },
  created() {
    Services.get("General/GetTiposActividad");
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
