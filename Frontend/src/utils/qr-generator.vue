<template>
  <div>
    <qrcode-vue :value="codigoQR" :size="sizeDeQR" :level="level"></qrcode-vue>
  </div>
</template>

<script>
import QrcodeVue from "qrcode.vue";

export default {
  name: "qrGen",
  components: {
    QrcodeVue
  },
  data() {
    return {
      codigoQR: {
        type: String,
        default: ""
      },
      sizeDeQR: {
        type: Number,
        default: 300
      },
      level: {
        type: String,
        default: "L"
      }
    };
  },
};
</script>
