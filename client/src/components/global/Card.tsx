import { ReactNode } from "react";
import { Box, BoxProps } from "@mui/material";

type MaterialUiBoxProps = { children: ReactNode } & BoxProps;

const Card: React.FC<MaterialUiBoxProps> = (props: MaterialUiBoxProps) => {
  const { children, ...cardprops } = props;
  return <Box {...cardprops}>{children}</Box>;
};

export default Card;
