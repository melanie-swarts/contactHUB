<template>
  <div>
    <label v-if="label">{{ label }}</label>
    <select :value="value" v-bind="$attrs" @change="updateValue" v-on="$listeners">
      <option
        v-for="option in options"
        :value="option"
        :key="option.id"
        :selected="option === value"
      >{{ option }}</option>
    </select>
  </div>
</template>

<script>
export default {
  name: 'BaseSelect',
  inheritAttrs: false,
  props: {
    options: {
      type: Array,
      required: true
    },
    value: [String, Number],
    label: String
  },
  methods: {
    updateValue(event) {
      this.$emit('input', event.target.value)
    }
  }
}
</script>
