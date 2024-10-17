import { Box, Pagination, Typography } from "@mui/material";
import { MetaData } from "../../models/pagination";

interface Props {
  metaData: MetaData;
  onPageChange: (page: number) => void;
}
const AppPagination: React.FC<Props> = (props: Props) => {
  const { metaData, onPageChange } = props;
  const { currentPage, totalPages, pageSize, totalCount } = metaData;

  return (
    <Box display="flex" justifyContent="center" alignItems="center">
      <Typography>
        Displaying {(currentPage - 1) * pageSize + 1}-
        {currentPage * pageSize > totalCount
          ? totalCount
          : currentPage * pageSize}{" "}
        of {totalCount} items
      </Typography>
      <Pagination
        color="secondary"
        size="large"
        count={totalPages}
        page={currentPage}
        onChange={(_, page) => onPageChange(page)}
      />
    </Box>
  );
};

export default AppPagination;
